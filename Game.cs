/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  
  private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();

    // her kan vi ændre navnene på kommandoerne - skal de være på dansk eller engelsk?
    registry.Register("exit", cmdExit); // Bruges til at afslutte spillet før tid.
    registry.Register("go", new CommandGo()); 
    registry.Register("help", new CommandHelp(registry));
    registry.Register("talk", new CommandTalk());
    registry.Register("inventory", new CommandInventory());

  }
  
  static void Main (string[] args) {
    
    // Vi mangler at tage stilling til dette:
    Console.WriteLine("Velkommen til --indsæt spilnavn her--, hvad hedder du?");
    Player player = context.GetPlayer();
    string spillernavn = player.GetName();
    Console.WriteLine("Hej " + spillernavn);
    
    InitRegistry();
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line!=null) registry.Dispatch(line);
    }
    Console.WriteLine("Du tabte! 😥");
  }
}
