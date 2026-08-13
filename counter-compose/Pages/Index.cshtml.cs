using Microsoft.AspNetCore.Mvc.RazorPages;
using StackExchange.Redis;


namespace CounterCompose.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDatabase _cache;
        public int CounterValue { get; private set; }

        public IndexModel(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        public async Task OnGetAsync()
        {
            string? cachedCounter = await _cache.StringGetAsync("hits");

            int.TryParse(cachedCounter, out int parsedValue);
            CounterValue = parsedValue;

            CounterValue++;

            await _cache.StringSetAsync("hits", CounterValue.ToString());
        }
    }
}
