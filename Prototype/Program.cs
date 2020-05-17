using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prototype example one");
            int counter = 0;
            var brainCell = new BrainCell(++counter);

            Cell cellOne = brainCell.Clone(++counter);
            Cell cellTwo = brainCell.Clone(++counter);
            Cell cellThree = brainCell.Clone(++counter);

            Console.WriteLine($"{Environment.NewLine}Prototype example two with build in c# interface");
            counter = 0;
            var brainCellTwo = new BrainCellTwo(++counter);
            BrainCellTwo CellOneOne = (BrainCellTwo)brainCellTwo.Clone();
            BrainCellTwo CellTwoTwo = (BrainCellTwo)brainCellTwo.Clone();
            BrainCellTwo CellThreeThree = (BrainCellTwo)brainCellTwo.Clone();

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }

    public abstract class Cell    
    {
        public int id { get; set; }
        public Cell(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return $"Cell id: {id}.";
        }
        public abstract Cell Clone(int id);        
        
    }

    public class BrainCell : Cell
    {
        public BrainCell(int id) : base(id)
        {
            Console.WriteLine($"BrainCell: {this}");
        }

        public override Cell Clone(int id)
        {
            return new BrainCell(id);
        }
    }

    public class BrainCellTwo: ICloneable
    {
        public int id { get; set; }

        public override string ToString()
        {
            return $"Cell id: {id}.";
        }

        public BrainCellTwo(int id)
        {
            this.id = id;
            Console.WriteLine($"BrainCell: {this}");
        }

        public object Clone()
        {
            return new BrainCellTwo(++id);
        }
    }
}
