using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vestager.Domain.Constants;

namespace Vestager.Application.Services
{
    public static class ArquivoService
    {
        public static string GetPath(string diretorio, string nomeArquivo)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), $"{CaminhoConstantes.ROOT}\\{diretorio}", nomeArquivo);
        }
        public static bool AdicionarArquivo(IFormFile file, string diretorio)
        {
            var path = GetPath(diretorio, file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                 file.CopyToAsync(stream).Wait();
            }
            return ExisteArquivo(path);
        }

        public static bool RemoverArquivo(string fileName, string diretorio)
        {
            var path = GetPath(diretorio, fileName);

            File.Delete(path);
            
            return !ExisteArquivo(path);
        }

        public static bool ExisteArquivo(string path)
        {
            return File.Exists(path);
        }

    }
}
