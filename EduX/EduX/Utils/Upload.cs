using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Utils
{
    public class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gera o nome do arquivo 
            //pega a extensão do arquivo 
            //concatena o nome do arquivo com sua extensão
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //GetCurrentDirectory - Pega o caminho do diretório atual
            var caminhaArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\Upload\imagens", nomeArquivo);

            //Crio um objeto do tipo FileStream passando o caminho do arquivo 
            //Passa para criar este arquivo 
            using var streamImagem = new FileStream(caminhaArquivo, FileMode.Create);

            //Executo o comando de criação do arquivo no local informado 
            file.CopyTo(streamImagem);

            return "http://localhost:44322/upload/imagens/" + nomeArquivo;

        }
    }
}
