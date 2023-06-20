using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (obj is IEnumerable collection && !(obj is string))  // Make sure it's not a string.
            {
                SerializeCollection(collection, sb, formatted, indentLevel);
            }
            else
            {
                SerializeObject(obj, sb, formatted, indentLevel);
            }
        }


        private static void SerializeCollection(IEnumerable collection, StringBuilder sb, bool formatted, int indentLevel)
        {
            sb.Append("[");

            if (formatted)
                sb.AppendLine();

            var items = collection.Cast<object>().ToList();
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];

                if (formatted)
                    AppendIndent(sb, indentLevel + 1);

                Serialize(item, sb, formatted, indentLevel + 1);

                if (i < items.Count - 1)
                    sb.Append(",");

                if (formatted)
                    sb.AppendLine();
            }

            if (formatted)
                AppendIndent(sb, indentLevel);

            sb.Append("]");
        }

        private static void SerializeObject(object obj, StringBuilder sb, bool formatted, int indentLevel)
        {
            var objectType = obj.GetType();
            var properties = TypeDescriptor.GetProperties(objectType);

            sb.Append("{");

            if (formatted)
                sb.AppendLine();

            for (int i = 0; i < properties.Count; i++)
            {
                var property = properties[i];
                var value = property.GetValue(obj);
                var propertyName = GetJsonPropertyName(property);

                if (formatted)
                    AppendIndent(sb, indentLevel + 1);

                sb.Append("\"").Append(propertyName).Append("\":");

                if (formatted)
                    sb.Append(" ");

                // Update here: check if the property is a string.
                if (property.PropertyType == typeof(string))
                {
                    sb.Append("\"").Append(value).Append("\"");  // Write the string value directly.
                }
                else if (IsPrimitiveType(property.PropertyType))
                {
                    sb.Append(Serialize(value));
                }
                else
                {
                    Serialize(value, sb, formatted, indentLevel + 1);
                }

                if (i < properties.Count - 1)
                    sb.Append(",");

                if (formatted)
                    sb.AppendLine();
            }

            if (formatted)
                AppendIndent(sb, indentLevel);

            sb.Append("}");
        }


        public static T Deserialize<T>(string json)
        {
            var obj = Deserialize(json, typeof(T));
            if (obj is T result)
                return result;

            throw new ArgumentException($"Invalid JSON: Cannot deserialize to type {typeof(T)}");
        }

        private static object Deserialize(object jsonObject, Type targetType)
        {
            if (jsonObject == null)
                throw new ArgumentException("Json object to deserialize is null");

            if (targetType == null)
                throw new ArgumentException("Target type is null");


            if (jsonObject is string json)
            {
                if (IsArrayJson(json))
                {
                    Type elementType;
                    IList list;

                    if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // Get the underlying type
                        elementType = targetType.GetGenericArguments()[0];
                        list = (IList)Activator.CreateInstance(targetType);
                    }
                    else
                    {
                        elementType = targetType.GetElementType();
                        if (elementType == null)
                            throw new Exception("Array has no element type");

                        list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
                    }

                    var jsonArrayItems = GetArrayElements(json);
                    foreach (var item in jsonArrayItems)
                    {
                        if(item != null)
                            list.Add(Deserialize(item.Trim(), elementType));
                    }

                    if (!targetType.IsArray)
                        return list;

                    Array array = Array.CreateInstance(elementType, list.Count);
                    for (int i = 0; i < list.Count; i++)
                    {
                        array.SetValue(list[i], i);
                    }
                    return array;
                }
                else if (!IsPrimitiveType(targetType))
                {
                    var dict = ParseJsonDictionary(json);
                    return Deserialize(dict, targetType);
                }
                else
                {
                    return ParseJsonValue(json);
                }
            }
            else if (jsonObject is Dictionary<string, object> dictionary)
            {
                var obj = Activator.CreateInstance(targetType);
                foreach (var kv in dictionary)
                {
                    var property = targetType.GetProperty(kv.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property != null)
                    {
                        if (!IsPrimitiveType(property.PropertyType) || property.PropertyType.IsArray ||
                            (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                        {
                            if (kv.Value != null)
                            {
                                var value = Deserialize(kv.Value, property.PropertyType);
                                property.SetValue(obj, value);
                            }
                        }
                        else
                        {
                            var value = Convert.ChangeType(kv.Value, property.PropertyType);
                            property.SetValue(obj, value);
                        }
                    }
                }
                return obj;
            }
            else if (jsonObject is List<object> objectList && targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type elementType = targetType.GetGenericArguments()[0];
                IList list = (IList)Activator.CreateInstance(targetType);

                // Handle an empty list
                if (objectList.Count == 0)
                    return list;

                foreach (var item in objectList)
                {
                    if(item != null)
                        list.Add(Deserialize(item, elementType));
                }

                return list;
            }
            else if (jsonObject.GetType().IsGenericType && jsonObject.GetType().GetGenericTypeDefinition() == typeof(List<>))
            {
                var objList = ((IEnumerable)jsonObject).Cast<object>().ToList();
                Type elementType = targetType.GetGenericArguments()[0];
                IList list = (IList)Activator.CreateInstance(targetType);

                if (elementType == typeof(string))
                {
                    foreach (var item in objList)
                    {
                        list.Add(Convert.ToString(item));
                    }
                }
                else
                {
                    foreach (var item in objList)
                    {
                        if(item != null)
                            list.Add(Deserialize(item, elementType));
                    }
                }

                return list;
            }
            else
            {
                throw new Exception("Unexpected type of JSON object: " + jsonObject.GetType());
            }
        }


        private static string DictionaryToJson(Dictionary<string, object> dict)
        {
            var keyValuePairs = dict.Select(kv =>
            {
                var valueStr = kv.Value is Dictionary<string, object>
                    ? DictionaryToJson(kv.Value as Dictionary<string, object>)
                    : kv.Value.ToString();
                return $"\"{kv.Key}\": {valueStr}";
            });
            return "{" + string.Join(", ", keyValuePairs) + "}";
        }


        private static bool IsArrayJson(string json)
        {
            json = json.Trim();
            return json.StartsWith("[") && json.EndsWith("]") && json.Length > 2;
        }

        private static List<string> GetArrayElements(string json)
        {
            var arrayElements = new List<string>();

            int bracketsCount = 0;
            int lastElementStartIndex = 1;

            for (int i = 1; i < json.Length - 1; i++)
            {
                if (json[i] == '{' || json[i] == '[')
                {
                    bracketsCount++;
                }
                else if (json[i] == '}' || json[i] == ']')
                {
                    bracketsCount--;
                }

                if (json[i] == ',' && bracketsCount == 0)
                {
                    arrayElements.Add(json.Substring(lastElementStartIndex, i - lastElementStartIndex));
                    lastElementStartIndex = i + 1;
                }
            }

            // Add the last element
            arrayElements.Add(json.Substring(lastElementStartIndex, json.Length - 1 - lastElementStartIndex));

            return arrayElements;
        }


        private static Dictionary<string, object> ParseJsonDictionary(string json)
        {
            var dictionary = new Dictionary<string, object>();
            json = json.Trim();
            if (json.StartsWith("{") && json.EndsWith("}"))
            {
                json = json.Substring(1, json.Length - 2);
                var keyValuePairs = SplitJsonIntoKeyValuePairs(json);

                foreach (var keyValuePair in keyValuePairs)
                {
                    var separatorIndex = keyValuePair.IndexOf(":");
                    if (separatorIndex != -1)
                    {
                        var key = keyValuePair.Substring(0, separatorIndex).Trim().Trim('"');
                        var value = keyValuePair.Substring(separatorIndex + 1).Trim();

                        if (IsObjectJson(value))
                            dictionary[key] = ParseJsonDictionary(value);
                        else if (IsArrayJson(value))
                            dictionary[key] = GetArrayElements(value);
                        else
                            dictionary[key] = ParseJsonValue(value);
                    }
                }
            }
            return dictionary;
        }

        private static bool IsObjectJson(string json)
        {
            json = json.Trim();
            return json.StartsWith("{") && json.EndsWith("}") && json.Length > 2;
        }

        private static List<string> SplitJsonIntoKeyValuePairs(string json)
        {
            var keyValuePairs = new List<string>();

            var depth = 0;
            var currentPair = new StringBuilder();
            foreach (var ch in json)
            {
                if (ch == '[' || ch == '{' || ch == '(')
                {
                    depth++;
                }
                else if (ch == ']' || ch == '}' || ch == ')')
                {
                    depth--;
                }

                if (ch == ',' && depth == 0)
                {
                    keyValuePairs.Add(currentPair.ToString().Trim());
                    currentPair.Clear();
                }
                else
                {
                    currentPair.Append(ch);
                }
            }

            if (currentPair.Length > 0)
            {
                keyValuePairs.Add(currentPair.ToString().Trim());
            }

            return keyValuePairs;
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
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // if it's a Nullable<T>, treat it as a primitive
                return true;
            }
            if (type.IsEnum)
            {
                // enum is treated as primitive
                return true;
            }

            var typeInfo = type.GetTypeInfo();

            return typeInfo.IsPrimitive ||
                   typeInfo.IsValueType ||
                   type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(float) ||
                   type == typeof(double) ||
                   type == typeof(bool) ||
                   type == typeof(int) ||
                   type == typeof(DateTime);
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
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.CanRead && !Attribute.IsDefined(p, typeof(VNetJsonIgnoreAttribute)) && !p.GetIndexParameters().Any()).ToArray();
        }


        private static string GetJsonPropertyName(PropertyDescriptor property)
        {
            var attribute = property.Attributes.OfType<VNetJsonPropertyAttribute>().FirstOrDefault();
            if (attribute != null && !string.IsNullOrEmpty(attribute.Name))
            {
                return attribute.Name;
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