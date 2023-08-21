using System;
using UniVerse.Services;
using UniVerse.Models;
using System.Diagnostics;

namespace UniVerse.ViewModels
{
	public class PeopleViewModel : BaseViewModel
	{
		public RestService _restService;
        public List<PeopleModel> PeopleList;

        public PeopleViewModel(RestService restService)
		{
			_restService = restService;
			PeopleList = new List<PeopleModel>();
		}

		public async Task GetAllPeople()
		{
			var items = await _restService.RefreshDataAsync();
			PeopleList.Clear();

			foreach(var item in items)
			{
				PeopleList.Add(item);
				Debug.WriteLine(item);
            }
		}
	}
}