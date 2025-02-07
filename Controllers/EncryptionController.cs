using Microsoft.AspNetCore.Mvc;

namespace EncryptionAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncryptionController : ControllerBase
    {
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            string encryptedText = CaesarCipher.Encrypt(text, 3);
            return Ok(encryptedText);
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string text)
        {
            string decryptedText = CaesarCipher.Decrypt(text, 3);
            return Ok(decryptedText);
        }
    }

    public static class CaesarCipher
    {
        public static string Encrypt(string text, int shift)
        {
            string result = "";

            foreach (char ch in text)
            {
                if (!char.IsLetter(ch))
                {
                    result += ch;
                    continue;
                }

                char offset = char.IsUpper(ch) ? 'A' : 'a';
                result += (char)(((ch + shift - offset) % 26) + offset);
            }

            return result;
        }

        public static string Decrypt(string text, int shift)
        {
            return Encrypt(text, 26 - shift);
        }
    }
}