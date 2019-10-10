using System.Collections.Generic;

namespace Waterskibaan
{
    public interface IWachtrij
    {
        void SporterNeemPlaatsInRij(Sporter sporter);
        List<Sporter> GetAlleSporters();
        List<Sporter> SportersVerlatenRij(int aantal);
    }
}