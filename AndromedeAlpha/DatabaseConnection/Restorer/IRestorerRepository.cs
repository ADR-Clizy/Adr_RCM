/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using System.Collections.Generic;

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
        List<Card> GetCards(int iId);
        bool IsRestorerSubscribed(int iId);
    }
}
