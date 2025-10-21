/* Command for showing player's inventory */
class CommandInventory : BaseCommand, ICommand
{
    public CommandInventory(){
        description = "Åben rygsæk.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        context.GetPlayer().ShowInventory();
    }
}
