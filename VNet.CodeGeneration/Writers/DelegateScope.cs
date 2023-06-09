using System.Linq;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class DelegateScope : Scope
    {
        public DelegateScope(string delegateName, string returnType, AccessModifier modifier, (string type, string name)[] parameters, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            var paramsList = string.Join(", ", parameters.Select(p => $"{p.type} {p.name}"));
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.GetAccessModifier(modifier)} {LanguageSettings.Keywords.DelegateKeyword} {returnType} {delegateName}({paramsList});");
        }
    }

}