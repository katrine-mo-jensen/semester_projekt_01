/* Fallback for when a command is not implemented 
 */
// Vi får stadig mange exceptions, når spilleren skriver forkert - det skal vi tage stilling til her, tror jeg.
class CommandUnknown : BaseCommand, ICommand {
  public void Execute (Context context, string command, string[] parameters) {
    Console.WriteLine("Woopsie, I don't understand '"+command+"' 😕"); 
  }
}
