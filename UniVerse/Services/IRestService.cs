using System;
using UniVerse.Models;

namespace UniVerse.Services
{
	public interface IRestService
	{
        //Define methods
        Task<List<PeopleModel>> RefreshDataAsync(); //GET ALL PEOPLE
    }
}

