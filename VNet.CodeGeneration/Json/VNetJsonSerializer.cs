using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VNet.CodeGeneration.Json
{
    public class VNetJsonSerializer
    {
        public static string Serialize(object obj, bool formatted = false)
        {
            if (obj == null)
                return "null";

            var objectType = obj.GetType();
            if (IsPrimitiveType(objectType))
                return FormatPrimitiveValue(obj);

            var sb = new StringBuilder();
            Serialize(obj, sb, formatted, 0);

            return sb.ToString();
        }

        private static void Serialize(object obj, StringBuilder sb, bool formatted, int indentLevel)
        {
            var objectType = obj.GetType();
            var isPrimitive = IsPrimitiveType(objectType);

            if (!isPrimitive)
                sb.Append("{");

            var properties = GetSerializableProperties(objectType);

            if (formatted && !isPrimitive)
                sb.AppendLine();

            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                var value = property.GetValue(obj);

                var propertyName = GetJsonPropertyName(property);
                if (formatted)
                    AppendIndent(sb, indentLevel + 1);

                sb.Append("\"").Append(propertyName).Append("\":");

                if (formatted)
                    sb.Append(" ");

                if (isPrimitive)
                {
                    sb.Append(Serialize(value));
                }
                else
                {
                    Serialize(value, sb, formatted, indentLevel + 1);
                }

                if (i < properties.Length - 1)
                    sb.Append(",");

                if (formatted)
                    sb.AppendLine();
            }

            if (!isPrimitive)
            {
                if (formatted)
                    AppendIndent(sb, indentLevel);

                sb.Append("}");
            }
        }

        public static T Deserialize<T>(string json)
        {
            var obj = Deserialize(json, typeof(T));
            if (obj is T result)
                return result;

            throw new ArgumentException($"Invalid JSON: Cannot deserialize to type {typeof(T)}");
        }

        private static object Deserialize(string json, Type targetType)
        {
            if (json == "null")
                return null;

            if (!IsPrimitiveType(targetType))
            {
                if (targetType.IsArray)
                {
                    var elementType = targetType.GetElementType();
                    if (elementType == null)
                        throw new ArgumentException($"Invalid JSON: Cannot deserialize to array type {targetType}");

                    var jsonArray = GetArrayElements(json);
                    var array = Array.CreateInstance(elementType, jsonArray.Count);

                    for (int i = 0; i < jsonArray.Count; i++)
                    {
                        var elementJson = jsonArray[i].ToString();
                        var elementValue = Deserialize(elementJson, elementType);
                        array.SetValue(elementValue, i);
                    }

                    return array;
                }
                else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var elementType = targetType.GetGenericArguments()[0];
                    var jsonArray = GetArrayElements(json);
                    var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));

                    for (int i = 0; i < jsonArray.Count; i++)
                    {
                        var elementJson = jsonArray[i].ToString();
                        var elementValue = Deserialize(elementJson, elementType);
                        list.Add(elementValue);
                    }

                    return list;
                }
                else
                {
                    var obj = Activator.CreateInstance(targetType);
                    var properties = GetSerializableProperties(targetType);
                    var jsonDictionary = ParseJsonDictionary(json);

                    foreach (var property in properties)
                    {
                        var propertyName = GetJsonPropertyName(property);
                        if (jsonDictionary.TryGetValue(propertyName, out var jsonValue))
                        {
                            var propertyValue = Deserialize(jsonValue.ToString(), property.PropertyType); // <-- Convert jsonValue to string
                            property.SetValue(obj, propertyValue);
                        }
                    }

                    return obj;
                }
            }
            else
            {
                return Convert.ChangeType(json, targetType, CultureInfo.InvariantCulture);
            }
        }

        private static bool IsArrayJson(string json)
        {
            json = json.Trim();
            return json.StartsWith("[") && json.EndsWith("]") && json.Length > 2;
        }

        private static List<string> GetArrayElements(string json)
        {
            var elements = new List<string>();

            json = json.Trim();
            if (json.Length > 2)
            {
                var startIndex = json.IndexOf("[") + 1;
                var endIndex = json.LastIndexOf("]");
                if (startIndex >= 0 && endIndex >= 0)
                {
                    var elementsJson = json.Substring(startIndex, endIndex - startIndex);
                    var depth = 0;
                    var currentElement = new StringBuilder();

                    foreach (var ch in elementsJson)
                    {
                        if (ch == '[' || ch == '{')
                        {
                            depth++;
                        }
                        else if (ch == ']' || ch == '}')
                        {
                            depth--;
                        }

                        if (ch == ',' && depth == 0)
                        {
                            elements.Add(currentElement.ToString());
                            currentElement.Clear();
                        }
                        else
                        {
                            currentElement.Append(ch);
                        }
                    }

                    if (currentElement.Length > 0)
                    {
                        elements.Add(currentElement.ToString());
                    }
                }
            }

            return elements;
        }

        private static Dictionary<string, object> ParseJsonDictionary(string json)
        {
            var dictionary = new Dictionary<string, object>();

            json = json.Trim();
            if (json.StartsWith("{") && json.EndsWith("}"))
            {
                json = json.Substring(1, json.Length - 2);
                var keyValuePairs = json.Split(',');

                foreach (var keyValuePair in keyValuePairs)
                {
                    var separatorIndex = keyValuePair.IndexOf(":");
                    if (separatorIndex != -1)
                    {
                        var key = keyValuePair.Substring(0, separatorIndex).Trim().Trim('"');
                        var value = keyValuePair.Substring(separatorIndex + 1).Trim();

                        dictionary[key] = ParseJsonValue(value);
                    }
                }
            }

            return dictionary;
        }

        private static object ParseJsonValue(string value)
        {
            if (value == "null")
                return null;

            if (value.StartsWith("\"") && value.EndsWith("\""))
                return value.Trim('"');

            if (int.TryParse(value, out int intValue))
                return intValue;

            if (float.TryParse(value, out float floatValue))
                return floatValue;

            if (double.TryParse(value, out double doubleValue))
                return doubleValue;

            if (bool.TryParse(value, out bool boolValue))
                return boolValue;

            return null;
        }

        private static bool IsPrimitiveType(Type type)
        {
            return type.IsPrimitive || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime);
        }

        private static string FormatPrimitiveValue(object value)
        {
            if (value is string stringValue)
                return $"\"{EscapeString(stringValue)}\"";

            if (value is DateTime dateTimeValue)
                return $"\"{dateTimeValue:s}\"";

            if (value is float floatValue)
                return floatValue.ToString("R", CultureInfo.InvariantCulture);

            if (value is double doubleValue)
                return doubleValue.ToString("R", CultureInfo.InvariantCulture);

            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        private static string EscapeString(string value)
        {
            var sb = new StringBuilder();
            foreach (var ch in value)
            {
                switch (ch)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        if (IsValidCharacter(ch))
                        {
                            sb.Append(ch);
                        }
                        else
                        {
                            sb.Append("\\u").Append(((int)ch).ToString("x4"));
                        }
                        break;
                }
            }
            return sb.ToString();
        }

        private static bool IsValidCharacter(char ch)
        {
            // Check if the character falls within the allowed Unicode range
            // (U+0020 to U+FFFF excluding the surrogate pair range U+D800 to U+DFFF)
            return ch >= '\u0020' && ch <= '\uD7FF' || ch >= '\uE000' && ch <= '\uFFFF';
        }

        private static PropertyInfo[] GetSerializableProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite)
                .ToArray();
        }


        private static string GetJsonPropertyName(PropertyInfo property)
        {
            var jsonPropertyAttribute = property.GetCustomAttribute<VNetJsonPropertyAttribute>();
            if (jsonPropertyAttribute != null && !string.IsNullOrEmpty(jsonPropertyAttribute.Name))
            {
                return jsonPropertyAttribute.Name;
            }

            return property.Name;
        }



        private static void AppendIndent(StringBuilder sb, int indentLevel)
        {
            const int indentSize = 4;
            sb.Append(' ', indentLevel * indentSize);
        }
    }
}