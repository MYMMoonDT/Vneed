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
        public static List<CoverFlowItem> FindAllCoverFlowItems()
        {
            return CoverFlowRepository.FindAllCoverFlowItems();
        }
    }
}
