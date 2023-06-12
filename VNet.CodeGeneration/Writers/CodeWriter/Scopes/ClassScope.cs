using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class ClassScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal ClassScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            

            return _codeLines;
        }
        //public sealed classScope(string name, Scope parent, IProgrammingLanguageSettings languageSettings)
        //    : base(name, parent, languageSettings)
        //{
        //    _isStatic = isStatic;
        //    _accessModifier = modifier;
        //    _className = className;
        //    _fields = fields ?? new (string Type, string Name, AccessModifier Modifier, bool IsStatic)[0];
        //}

        //public sealed classScope(string className, IProgrammingLanguageSettings languageSettings)
        //    : this(className, false, AccessModifier.Public, languageSettings)
        //{
        //}

        //public PropertyScope WithProperty(string propertyName, string propertyType)
        //{
        //    var propertyScope = new PropertyScope(propertyName, propertyType, _isStatic, _accessModifier, null, null, _stringBuilder, LanguageSettings);
        //    AddNestedScope(propertyScope);
        //    return propertyScope;
        //}

        //public MethodScope WithMethod(string methodName, string returnType, params (string Type, string Name)[] parameters)
        //{
        //    var methodScope = new MethodScope(methodName, returnType, false, _accessModifier, parameters, _stringBuilder, LanguageSettings);
        //    AddNestedScope(methodScope);
        //    return methodScope;
        //}

        //public ConstructorScope WithConstructor(params (string Type, string Name)[] parameters)
        //{
        //    var constructorScope = new ConstructorScope(_className, parameters, LanguageSettings);
        //    AddNestedScope(constructorScope);
        //    return constructorScope;
        //}

        //public sealed classScope WithAttribute(string attributeName, params string[] args)
        //{
        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}[{LanguageSettings.Syntax.GetAttributeSyntax(attributeName, args)}]");
        //    return this;
        //}

        //public sealed classScope WithDocumentationComment(string comment, CommentType commentType)
        //{
        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Syntax.GetCommentSyntax(comment, commentType)}");
        //    return this;
        //}

        //public sealed classScope WithStatic(bool isStatic = true)
        //{
        //    _isStatic = isStatic;
        //    return this;
        //}

        //public sealed classScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _accessModifier = modifier;
        //    return this;
        //}

        //public sealed classScope WithFields(params (string Type, string Name, AccessModifier Modifier, bool IsStatic)[] fields)
        //{
        //    _fields = fields;
        //    return this;
        //}
    }
}