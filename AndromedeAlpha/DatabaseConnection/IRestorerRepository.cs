using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public interface IRestorerRepository
    {
        Restorer GetRestorerWithId(int iId);
        Restorer GetRestorerWithEmailAddress(string iEmailAddress);
        Restorer GetRestorerWithRestaurantSiretNumber(string iRestaurantSiretNumber);
        IEnumerable<Restorer> GetAllRestorer();
        Restorer NewRestorer(Restorer ioRestorer);
        Restorer UpdateProfile(Restorer ioRestorerChanges);
        Restorer DeleteProfile(int iId);
        bool IsRestorerSubscribed(int iId);
    }
}
