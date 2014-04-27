using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySocial.Services
{
    public class TwitterService : BaseService, ITwitterService
    {
        public TwitterService(ISettings settings): base(settings)
        {
            
        }
    }
}
