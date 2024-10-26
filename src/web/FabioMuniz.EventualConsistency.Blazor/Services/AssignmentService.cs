using FabioMuniz.EventualConsistency.Blazor.Extensions;
using FabioMuniz.EventualConsistency.Blazor.Models;
using System.Text;
using System.Text.Json;

namespace FabioMuniz.EventualConsistency.Blazor.Services
{
	public class AssignmentService(IHttpClientFactory httpClientFactory) : IAssignmentService
	{
		public async Task<IEnumerable<AssignmentModel>> GetAllAssignmentsAsync()
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.QueryAPI.ClientName);

			try
			{
				return await httpClient.GetFromJsonAsync<IEnumerable<AssignmentModel>>("assignments");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<AssignmentModel> GetAssignmentByIdAsync(Guid id)
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.QueryAPI.ClientName);

			try
			{
				return await httpClient.GetFromJsonAsync<AssignmentModel>($"assignments/{id}");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public async Task<bool> CreateAssignmentAsync(AssignmentModel assignment)
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.CommandAPI.ClientName);

			try
			{
				var request = SerializeContent(assignment);

				var response = await httpClient.PostAsync("assignments", request);

				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> DeleteAssignmentAsync(Guid id)
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.CommandAPI.ClientName);

			try
			{
				var response = await httpClient.DeleteAsync($"assignments/{id}");

				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public async Task<bool> UpdateAssignmentAsync(Guid id, bool completed)
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.CommandAPI.ClientName);

			try
			{
				var request = SerializeContent(new { Id = id, Completed = completed });

				var response = await httpClient.PutAsync($"assignments/{id}", request);

				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private StringContent SerializeContent(object content)
		{
			return new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
		}
	}
}
