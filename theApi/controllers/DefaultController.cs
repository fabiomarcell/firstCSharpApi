using Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using theApi.ViewModels;
using System.Data;
namespace theApi.controllers
{
    //raiz
    [RoutePrefix( "" )]
    public class DefaultController : ApiController {
        //força aplicação receber somente get da aplicação
        //url a partir da raiz
        [HttpGet]
        [Route( "" )]
        public HttpResponseMessage getIndex( ) {
            try {
                return Request.CreateResponse( HttpStatusCode.OK, "Hello!" );
            }
            catch( Exception ex ) {
                return Request.CreateResponse( HttpStatusCode.BadRequest, ex.Message );
            }
        }

        [HttpGet]
        [Route( "vagabundo" )]
        public HttpResponseMessage getVagabundo( ) {
            try {
                return Request.CreateResponse( HttpStatusCode.OK, "Sim, vc é" );
            }
            catch( Exception ex ) {
                return Request.CreateResponse( HttpStatusCode.BadRequest, ex.Message );
            }
        }

        [HttpGet]
        //parametros de url{var:tipo}
        [Route( "consulta/cliente/{id:int}" )]
        public HttpResponseMessage getCliente( int id ) {
            try {
                var clientes = new[ ] { 
                    new { id = 1, nome = "Fabio", idade = 21 } ,
                    new { id = 2, nome = "Teste", idade = 31 } 
                };

                var cliente = clientes.Where( x => x.id == id ).FirstOrDefault( );
                if( cliente == null ) {
                    throw new Exception( "Cliente Inexistente" );
                }

                return Request.CreateResponse( HttpStatusCode.OK, cliente );
            }
            catch( Exception ex ) {
                return Request.CreateResponse( HttpStatusCode.OK, ex.Message );
            }
        }

        [HttpGet]
        [Route( "consulta/todos-clientes" )]
        public HttpResponseMessage getTodosClientes( ) {
            try {
                var clientes = new[ ] { 
                    new { id = 1, nome = "Fabio", idade = 21 } ,
                    new { id = 2, nome = "Teste", idade = 31 } 
                };

                return Request.CreateResponse( HttpStatusCode.OK, clientes );
            }
            catch( Exception ex ) {
                return Request.CreateResponse( HttpStatusCode.NoContent, ex.Message );
            }
        }

        [HttpPost]
        [Route( "cadastro/cliente" )]
        public HttpResponseMessage cadastrarCliente( Cliente cliente ) {
            try {
                return Request.CreateResponse( HttpStatusCode.OK, cliente );
            }
            catch( Exception ex ) {
                return Request.CreateResponse( HttpStatusCode.BadRequest, ex.Message );
            }
        }
        
        [HttpGet]
        [Route( "tarefas/listar-todas" )]
        public HttpResponseMessage listarTarefas( ) {
            try {
                ListRepository lr = new ListRepository();
                return Request.CreateResponse( HttpStatusCode.OK, lr.listarTodos() );
            }
            catch( Exception ex ) {
                return Request.CreateResponse( HttpStatusCode.BadRequest, ex.Message );
            }
        }
        
    }

}
