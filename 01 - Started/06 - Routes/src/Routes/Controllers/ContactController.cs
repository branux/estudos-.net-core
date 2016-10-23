using Microsoft.AspNetCore.Mvc;

namespace Routes.Controllers
{
    //[Route("Contact")]
    //[Route("[controller]")]
    [Route("[controller]/[action]")]
    public class ContactController
    {
        //[Route("")]
        public string Phone() {
            return "+55 11 5555-5555";
        }


        //[Route("endereco")]
        public string Address()
        {
            return "Rua Tabajara, 555, Jardim Teste - SP / Brasil";
        }
    }
}
