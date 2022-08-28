using System;
using Laboratorio01.Data_Structure;
using Laboratorio01.Models;

namespace Laboratorio01.Helpers
{
    public class Data
    {
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }

  
        public AVLtree<ClientModel> miArbolAvlId = new AVLtree<ClientModel>
        {
            Comparar = Comparison.Comparison.CompararID
        };

        


    }
}

