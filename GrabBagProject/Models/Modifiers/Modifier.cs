namespace GrabBagProject.Models.Modifiers
{
    internal abstract class Modifier
    {
        public IModifierHolder ModifierHolder { get; set; }
        public override string ToString()
        {
            return string.Empty;
        }
    }
}


