/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  private Player player;
  
  public Context (Space node) {
    current = node;
    player = new Player();
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
    private string[] inventory;
    private int inventoryCount;

    public Player(int maxInventorySize = 10)
    {
        inventory = new string[maxInventorySize];
        inventoryCount = 0;
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
