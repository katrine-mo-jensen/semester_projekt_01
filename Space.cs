/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  private string welcomeMessage;
  public Space(string name, string message = "") : base(name)
{
    welcomeMessage = message;
}

  
  public void Welcome () {
     if (!string.IsNullOrEmpty(welcomeMessage)){
            Console.WriteLine(welcomeMessage);   // <--- dette viser din specielle besked
            
        }
        else
        {
            Console.WriteLine("You are now at "+name);
        }
        HashSet<string> exits = edges.Keys.ToHashSet();
            Console.WriteLine("Current exits are:");
            foreach (String exit in exits) {
            Console.WriteLine(" - "+exit);
        }
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
}
