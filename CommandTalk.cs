class CommandTalk : BaseCommand, ICommand
{
    public CommandTalk()
    {
        description = "Talk to someone in the room"; // dansk?
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        Space current = context.GetCurrent();
        
        if (current.GetName() == "Klasselokalet")
        {
            if (!context.GetPlayer().HasItem("rygsæk"))
            {
                context.GetPlayer().AddItem("rygsæk");
                Console.WriteLine("Underviseren giver dig en rygsæk! 🎒 Nu kan du rejse videre.");
            }
            else
            {
                Console.WriteLine("Du har allerede en rygsæk.");
            }
        }
        else
        {
            Console.WriteLine("Der er ingen at tale med her.");
        }
    }
}
