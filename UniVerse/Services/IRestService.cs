using System;
using UniVerse.Models;

namespace UniVerse.Services
{
	public interface IRestService
	{
        Task<List<PersonModel>> RefreshDataAsync(); //GET ALL PEOPLE
    }
}