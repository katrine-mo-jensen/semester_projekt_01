/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
    Space entry    = new Space("Landbrugsskolen");
    Space mose = new Space("Mosen");
    Space mark     = new Space("Marken");
    Space vandløb      = new Space("Vandløbet");
    
    entry.AddEdge("north", mose);
    entry.AddEdge("south", mark);
    entry.AddEdge("east", vandløb);
    
    
    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

