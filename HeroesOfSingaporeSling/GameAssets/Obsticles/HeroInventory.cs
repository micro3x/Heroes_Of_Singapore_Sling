using System;
using System.Collections.Generic;
using System.Linq;

namespace GameAssets.Obsticles
{


    [Serializable]
    public class HeroInventory
    {
        private readonly bool[,] inventoryGrid = new bool[14,13];
        private readonly List<Items> containingItems  = new List<Items>();


        public List<Items> ContainingItems
        {
            get
            {
                return containingItems.AsReadOnly().ToList();
            }
        }

        public bool DropToInventory(Items item, int dropLocationLeft, int dropLocationTop, bool isMove = false)
        {
            if (item == null)
            {
                return false;
            }
            Tuple<int, int> position = CalculatePositionToGrid(dropLocationLeft, dropLocationTop);
            var space = CalculateGridSpace(item);
            if (isMove)
            {
                var spaceToRelease = CalculateGridSpace(item);
                var positionToRelease = CalculatePositionToGrid( item.PositionTop,item.PositionLeft);
                ReleeseSpace(spaceToRelease, positionToRelease);
                if (OccupyedSpaceCheck(space, position))
                {
                    
                    item.PositionLeft = position.Item2 * 20;
                    item.PositionTop = position.Item1 * 20;
                    OccupySpace(space, position);
                    return true;
                    //maybe raise event
                }
                else
                {
                    OccupySpace(spaceToRelease, positionToRelease);
                }
                return true;
            }
            else
            {
                if (OccupyedSpaceCheck(space, position))
                {
                    item.PositionLeft = position.Item2*20;
                    item.PositionTop = position.Item1*20;
                    containingItems.Add(item);
                    OccupySpace(space, position);
                    return true;
                    //maybe raise event
                }
            }
            return false;
        }

        public bool Take(Items item)
        {

            var location = FindLocation(item);
            if (location != null)
            {
                DropToInventory(item, location.Item1, location.Item2);
                return true;
            }
            return false;
        }

        public void RemoveFromInventory(Guid itemId)
        {
            var itemToRemove = containingItems.First(x => x.Id == itemId);
            if (itemToRemove == null)
            {
                return;
            }
            ReleeseSpace(CalculateGridSpace(itemToRemove),
                CalculatePositionToGrid(itemToRemove.PositionTop, itemToRemove.PositionLeft));
            containingItems.Remove(itemToRemove);
        }


        private Tuple<int,int> FindLocation(Items item)
        {
            var space = CalculateGridSpace(item);
            for (int postionInInvRow = 0; postionInInvRow < (inventoryGrid.GetLength(0) - space.GetLength(0)); postionInInvRow++)
            {
                for (int postionInInvCol = 0; postionInInvCol < (inventoryGrid.GetLength(1) - space.GetLength(1)); postionInInvCol++)
                {
                    if (OccupyedSpaceCheck(space, new Tuple<int, int>(postionInInvRow,postionInInvCol) ))
                    {
                        return new Tuple<int, int>(postionInInvRow * 20, postionInInvCol * 20);
                    }
                }
            }
            return null;
        }

        private void OccupySpace(bool[,] space, Tuple<int,int> leftTopGridPosition)
        {
            for (int spaceToOccupyRow = leftTopGridPosition.Item1; spaceToOccupyRow < leftTopGridPosition.Item1+space.GetLength(0); spaceToOccupyRow++)
            {
                for (int spaceToOccupyCola = leftTopGridPosition.Item2; spaceToOccupyCola < leftTopGridPosition.Item2+space.GetLength(1); spaceToOccupyCola++)
                {
                    inventoryGrid[spaceToOccupyRow, spaceToOccupyCola] = true;
                }
            }
        }
        private bool OccupyedSpaceCheck(bool[,] space, Tuple<int, int> leftTopGridPosition)  
        {
            if (leftTopGridPosition.Item1 + space.GetLength(0) > inventoryGrid.GetLength(0))
            {
                return false;
            }
            if (leftTopGridPosition.Item2 + space.GetLength(1) > inventoryGrid.GetLength(1))
            {
                return false;
            }

            for (int spaceToOccupyRow = leftTopGridPosition.Item1; spaceToOccupyRow < leftTopGridPosition.Item1+space.GetLength(0) ; spaceToOccupyRow++)
            {
                for (int spaceToOccupyCol = leftTopGridPosition.Item2; spaceToOccupyCol < leftTopGridPosition.Item2+space.GetLength(1); spaceToOccupyCol++)
                {
                    if (inventoryGrid[spaceToOccupyRow,spaceToOccupyCol])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool[,] CalculateGridSpace(Items item)
        {

            int colsLenght = item.InventoryImage.Width/20;
            int rowsLenght = item.InventoryImage.Height/20;
            bool[,] output = new bool[rowsLenght,colsLenght];
            return output;
        }

        private Tuple<int, int> CalculatePositionToGrid(int row, int col)
        {
            Tuple<int,int> output = new Tuple<int, int>((row/20) ,(col/20));
            return output;
        }

        private void ReleeseSpace(bool[,] space, Tuple<int, int> rowColGridPosition)
        {
            for (int spaceToOccupyRow = rowColGridPosition.Item1; spaceToOccupyRow < rowColGridPosition.Item1 + space.GetLength(0); spaceToOccupyRow++)
            {
                for (int spaceToOccupyCola = rowColGridPosition.Item2; spaceToOccupyCola < rowColGridPosition.Item2 + space.GetLength(1); spaceToOccupyCola++)
                {
                    inventoryGrid[spaceToOccupyRow, spaceToOccupyCola] = false;
                }
            }
        }


    }
}
