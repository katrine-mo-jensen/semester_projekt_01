/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  bool hasBackpack = false;
  
  public World () {
    Space entry    = new Space("Landbrugsskolen");
    Space classroom = new Space("Klasselokalet", "Du er nu i klasselokalet. Du kan snakke med din underviser, brug talk");
// hovedrum mose:
    Space mose = new Space("Mosen");
// underrum mose:
    Space mosekant = new Space("Mosekant");
    Space tørvemose = new Space ("Tørvemosen");
    Space udtørretEng = new Space ("Udtørret eng");

// hovedrum 2 (mark)
    Space mark     = new Space("Marken");
// underrum


//hovedrum 3 (vandløb)
    Space vandløb      = new Space("Vandløbet");
    
    entry.AddEdge("fortiden", mose);
    entry.AddEdge("mark", mark);
    entry.AddEdge("fremtiden", vandløb);
    entry.AddEdge("klasselokalet", classroom);
    classroom.AddEdge("tilbage", entry);
    mose.AddEdge("mosekant", mosekant);
    mosekant.AddEdge("tørvemose", tørvemose);
    udtørretEng.AddEdge("engen", udtørretEng);
    
    
    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

