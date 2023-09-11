using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Internal;

// This trivial WebAPI works like this: you put something using particular key, and get it back using the same key. You have 1 minute for it.
// Everything is kept in memory, nothing is saved to disk.

namespace LexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        // GET api/<MessageController>/944aa2547bef41338f9996017deb171d
        [HttpGet("{channelID}")]
        public string Get(string channelID)
        {
            string cvName = "msg" + channelID;
            var result = Caching.GetCacheString(cvName);
            if (string.IsNullOrEmpty(result)) return result;
            Caching.AddAbsoluteCache2(null,1,cvName);
            Caching.ClearCache(cvName);//We only let the string to be retrieved once
            return result;
        }

        // POST api/<MessageController>
        [HttpPost]
        public void Post(string channelID, [FromBody] string value)
        {
            string cvName = "msg" + channelID;
            Caching.ClearCache(cvName);
            Caching.AddAbsoluteCache(value,1,cvName);
        }
        
    }
}
