/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  private Player player;
  
  public Context (Space node) {
    current = node;
    player = new Player();
    player.SetName();
   
  }
  
  public Player GetPlayer() {
        return player;
    }

  public Space GetCurrent() {
    return current;
  }

  
  public void Transition (string direction) {

    Space next = current.FollowEdge(direction);

    if (next==null) {
      Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
      return;
    }
     // tjek om spiller har rygsæk
    if (!player.HasItem("rygsæk") && next.GetName() != "Klasselokalet")
        {
            Console.WriteLine("Du kan ikke rejse i tiden uden en rygsæk – snak med din underviser.");
            return;
        }

      // tjek om spiller har nøgle
    if (!player.HasItem("indsæt nøgle navn") && next.GetName() == "Marken")
      {
            Console.WriteLine("Nutiden er låst, du mangler en nøgle");
            return;
      }

         // tjek om spiller har nøgle
    if (!player.HasItem("indsæt nøgle navn2") && next.GetName() == "Vandløbet")
      {
            Console.WriteLine("Fremtiden er låst, du mangler en nøgle");
            return;
      }

      current.Goodbye();
      current = next;
      current.Welcome();
  }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }

  
}

class Player 
{
    private string name;
    private string[] inventory;
    private int inventoryCount;

    public Player(int maxInventorySize = 10)
    {
        inventory = new string[maxInventorySize];
        inventoryCount = 0;
        name = "unavngivet";
    }

    
    public void SetName() {
      while (true) {
      Console.Write("> ");
      string? input = Console.ReadLine();   

      if (!string.IsNullOrEmpty(input)){
        this.name = input;
        break; 
    }
    Console.WriteLine("Navnet kan ikke være tomt!");
      }
    

    }

    public string GetName() {
      return this.name;

    }
// Tjek om spilleren har en genstand
    public bool HasItem(string item)
    {
        for(int i = 0; i < inventoryCount; i++)
        {
            if(inventory[i] == item) return true;
        }
        return false;
    }

    // Tilføj genstand
    public void AddItem(string item)
    {
        if(HasItem(item))
        {
            Console.WriteLine($"Du har allerede: {item}");
            return;
        }

        if(inventoryCount < inventory.Length)
        {
            inventory[inventoryCount] = item;
            inventoryCount++;
            Console.WriteLine($"Du har fået: {item}");
        }
        else
        {
            Console.WriteLine("Din rygsæk er fuld! Du kan ikke tage mere med.");
        }
    }

    //  print inventory
    public void ShowInventory(){
     
        if (inventory[0] == null) {
          Console.WriteLine("Du mangler en rygsæk, snak med din underviser!"); }
          else if (inventory[1] == null){
            Console.WriteLine("Din rygsæk er tom!");
          }
          else {
               Console.WriteLine("Du har i din rygsæk:");
              
          for(int i = 1; i < inventoryCount; i++){
            Console.WriteLine($"- {inventory[i]}");
        }
          }
    }
}
