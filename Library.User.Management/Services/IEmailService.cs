using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.User.Management.Models;

namespace Library.User.Management.Services
{
    public interface IEmailService
    {
        void sendEmail(Message message);
    }
}
