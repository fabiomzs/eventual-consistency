using FabioMuniz.EventualConsistency.Blazor.Extensions;
using FabioMuniz.EventualConsistency.Blazor.Models;
using System.Text;
using System.Text.Json;

namespace FabioMuniz.EventualConsistency.Blazor.Services
{
	public class AssignmentService(IHttpClientFactory httpClientFactory) : IAssignmentService
	{
		public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.QueryAPI.ClientName);

			try
			{
				return await httpClient.GetFromJsonAsync<IEnumerable<Assignment>>("assignments");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<Assignment> GetAssignmentByIdAsync(Guid id)
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.QueryAPI.ClientName);

			try
			{
				return await httpClient.GetFromJsonAsync<Assignment>($"assignments/{id}");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public async Task<bool> CreateAssignmentAsync(Assignment assignment)
		{
			using HttpClient httpClient = httpClientFactory.CreateClient(AppSettings.CommandAPI.ClientName);

			try
			{
				var request = SerializeContent(assignment);

				var response = await httpClient.PostAsync("asignments", request);

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
				var response = await httpClient.DeleteAsync($"asignments/{id}");

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

				var response = await httpClient.PutAsync($"asignments/{id}", request);

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
