using GtiTeste.AppMVC.DTO;
using GtiTeste.AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Web.Mvc;

namespace GtiTeste.AppMVC.Controllers
{
    public class ClienteController : Controller
    {
        HttpClient _client;
        public ClienteController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["CaminhoApi"]);
        }
        public ActionResult Index()
        {
            var response = _client.GetAsync("/obter-clientes").Result;
            // Retorna dos dados dos clientes
            var clientes = DeserializarObjetoResponse<List<ClienteModel>>(response);

            return View(clientes);
        }

        public ActionResult Incluir()
        {
            PopularViewBags();
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ClienteModel cliente)
        {
            var response = _client.PostAsync("/incluir-cliente", ObterConteudo(cliente)).Result;

            var retorno = DeserializarObjetoResponse<RetornoOperacaoDTO>(response);

            if (retorno.OperacaoValida)
            {
                TempData["MensagemSucesso"] = "Cliente incluído com sucesso!";
                return RedirectToAction("Index");
            }
            else
            {
                ProcessarMensagensErro(retorno.Mensagens.ToList());
                PopularViewBags();

                return View(cliente);
            }
        }

        public ActionResult Alterar(Guid Id)
        {
            var response = _client.GetAsync($"/obter-cliente?id={Id}").Result;
            var cliente = DeserializarObjetoResponse<ClienteModel>(response);

            PopularViewBags(cliente);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(ClienteModel cliente)
        {
            var response = _client.PutAsync("/alterar-cliente", ObterConteudo(cliente)).Result;

            var retorno = DeserializarObjetoResponse<RetornoOperacaoDTO>(response);

            if (retorno.OperacaoValida)
            {
                TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
            }
            else
            {
                ProcessarMensagensErro(retorno.Mensagens.ToList());
            }
            PopularViewBags(cliente);
            return View(cliente);
        }

        public ActionResult Detalhes(Guid Id)
        {
            // Retorna detalhes do cliente
            var response = _client.GetAsync($"/obter-cliente?id={Id}").Result;

            var cliente = DeserializarObjetoResponse<ClienteModel>(response);

            return View(cliente);
        }

        public ActionResult Excluir(Guid Id)
        {
            var response = _client.DeleteAsync($"/excluir-cliente?id={Id}").Result;

            var retorno = DeserializarObjetoResponse<RetornoOperacaoDTO>(response);

            if (retorno.OperacaoValida)
            {
                TempData["MensagemSucesso"] = "Cliente excluído com sucesso!";
            }
            else
            {
                ProcessarMensagensErro(retorno.Mensagens.ToList());
            }
            return RedirectToAction("Index");
        }

        protected T DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(responseMessage.Content.ReadAsStringAsync().Result, options);
        }

        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        }

        private void ProcessarMensagensErro(List<string> mensagens)
        {
            var mensagem = string.Empty;
            foreach (var mensagemErro in mensagens)
            {
                mensagem += $"<li> {mensagemErro} </li>";
            }
            TempData["MensagemErro"] = mensagem;
        }

        private void PopularViewBags(ClienteModel cliente = null)
        {
            var responseEstados = _client.GetAsync("/obter-todos-estados").Result;
            var estados = DeserializarObjetoResponse<List<EstadoModel>>(responseEstados);
            
            if (cliente != null)
            {
                ViewBag.EstadosCliente = new SelectList(estados.OrderBy(x => x.Sigla), "Sigla", "Sigla", cliente.UF);
                ViewBag.EstadosEndereco = new SelectList(estados.OrderBy(x => x.Sigla), "Sigla", "Sigla", cliente.Endereco.UF);
                ViewBag.ListaEstadoCivil = new SelectList(RetornarListaEstadoCivilDropDown(), "Valor", "Texto", cliente.EstadoCivil);
                ViewBag.ListaSexo = new SelectList(RetornarListaSexoDropDown(), "Valor", "Texto", cliente.Sexo);
            }
            else
            {
                ViewBag.EstadosCliente = new SelectList(estados.OrderBy(x => x.Sigla), "Sigla", "Sigla");
                ViewBag.EstadosEndereco = new SelectList(estados.OrderBy(x => x.Sigla), "Sigla", "Sigla");
                ViewBag.ListaEstadoCivil = new SelectList(RetornarListaEstadoCivilDropDown(), "Valor", "Texto");
                ViewBag.ListaSexo = new SelectList(RetornarListaSexoDropDown(), "Valor", "Texto");
            }
        }

        private List<ItemsDropDownListDTO> RetornarListaEstadoCivilDropDown()
        {
            return new List<ItemsDropDownListDTO>() {
          new ItemsDropDownListDTO(){Valor =" ", Texto ="Selecione..." },
          new ItemsDropDownListDTO(){Valor ="Solteiro", Texto ="Solteiro" },
          new ItemsDropDownListDTO(){Valor ="Casado", Texto ="Casado" },
          new ItemsDropDownListDTO(){Valor ="Divorciado", Texto ="Divorciado" },
          new ItemsDropDownListDTO(){Valor ="Viuvo", Texto ="Viúvo" },
         };
        }

        private List<ItemsDropDownListDTO> RetornarListaSexoDropDown()
        {
            return new List<ItemsDropDownListDTO>() {
          new ItemsDropDownListDTO(){Valor =" ", Texto ="Selecione..." },
          new ItemsDropDownListDTO(){Valor ="Feminino", Texto ="Feminino" },
          new ItemsDropDownListDTO(){Valor ="Masculino", Texto ="Masculino" },
          new ItemsDropDownListDTO(){Valor ="Outro", Texto ="Outro" }
         };
        }
    }
}