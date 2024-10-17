namespace GrabBagProject.Models.Commands
{
    internal class Command : IInteractable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Keys { get; set; }
        public Command(string name, string description, string[] keys)
        {
            Name = name;
            Description = description;
            Keys = keys;
        }

        public override string ToString()
        {
            string allKeys = Keys.Aggregate("", (all, next) => all += "|" + next);
            return $"{Name} - [{allKeys.Substring(1)}] - {Description}";
        }

        public string GetDescription() { return Description; }
    }
}
