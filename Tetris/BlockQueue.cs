using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        //Creates an array full of all of the game's blocks
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        //Random seed to pick the next block
        private readonly Random random = new Random();

        //next block block object
        public Block NextBlock { get; private set; }

        //Initializes next block
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        //Picks a new block based off the random seed in the array
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //returns a random new block then generates the next block as long as its not the same block
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
