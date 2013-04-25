using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vneed.Model;
using Vneed.DAL.Repository;

namespace Vneed.BLL
{
    public class CoverFlowService
    {
        public static List<CoverFlowItem> GetAll()
        {
            return CoverFlowRepository.GetAll();
        }

        public static void Add(CoverFlowItem newCoverFlowItem)
        {
            newCoverFlowItem.Pos = CoverFlowRepository.AllocateNewPos();
            CoverFlowRepository.Add(newCoverFlowItem);
        }

        public static void Delete(int pos)
        {
            CoverFlowRepository.Delete(pos);
        }

        public static void MoveUp(int oldPos)
        {
            int neighbour = CoverFlowRepository.UpsideNeighbour(oldPos);
            if (neighbour == -1) return;
            CoverFlowRepository.SwapPos(oldPos, neighbour);
        }

        public static void MoveDown(int oldPos)
        {
            int neighbour = CoverFlowRepository.DownsideNeighbour(oldPos);
            if (neighbour == -1) return;
            CoverFlowRepository.SwapPos(oldPos, neighbour);
        }
    }
}
