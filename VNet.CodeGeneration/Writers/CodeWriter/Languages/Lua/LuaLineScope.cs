using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public abstract class LuaLineScope<T> : LineScope where T : LuaLineScope<T>
    {
        protected LuaLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }
    }
}