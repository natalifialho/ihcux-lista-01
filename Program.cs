/*
 * DISCIPLINA: Interação Humano Computador e UX
 * PROFESSOR: Daniel Henrique Matos de Paiva
 * ALUNO: NÁTALI FIALHO SOARES
 * * APLICAÇÃO DAS HEURÍSTICAS DE NIELSEN:
 * 1. Heurística #1 (Visibilidade do Status): Implementada no cabeçalho de cada etapa [Passo X de 3].
 * 2. Heurística #3 (Controle e Liberdade): Uso dos comandos "voltar" para retornar à etapa anterior e "cancelar" para reiniciar.
 * 3. Heurística #9 (Ajuda e Erros): Mensagens de erro específicas para entradas não numéricas e códigos fora do intervalo (1-10).
 */

using System;

namespace CaosNaCantina
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variáveis de controle do pedido
            int codigoProduto = 0;
            int quantidade = 0;
            int etapa = 1; // Controla em qual passo o usuário está

            Console.WriteLine("=== Bem-vindo ao Sistema da Cantina ===");
            Console.WriteLine("Dicas: Digite 'voltar' para a etapa anterior ou 'cancelar' para sair.");

            while (etapa <= 3)
            {
                switch (etapa)
                {
                    case 1: // ETAPA 1: Seleção de Código
                        Console.WriteLine("\n-------------------------------------------");
                        Console.WriteLine("[Passo 1 de 3] Seleção de Item"); // Heurística #1
                        Console.Write("Digite o código do produto (1 a 10): ");
                        string input1 = Console.ReadLine()?.ToLower();

                        if (input1 == "cancelar") return;
                        if (input1 == "voltar") 
                        {
                            Console.WriteLine("Você já está no início.");
                            continue;
                        }

                        if (int.TryParse(input1, out codigoProduto))
                        {
                            if (codigoProduto >= 1 && codigoProduto <= 10)
                            {
                                etapa++; // Avança
                            }
                            else
                            {
                                // Heurística #9: Erro explicativo
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Erro: Código {codigoProduto} não encontrado. Nossos códigos vão de 1 a 10. Tente novamente.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erro: Por favor, digite um número válido.");
                            Console.ResetColor();
                        }
                        break;

                    case 2: // ETAPA 2: Quantidade
                        Console.WriteLine("\n-------------------------------------------");
                        Console.WriteLine("[Passo 2 de 3] Definição de Quantidade"); // Heurística #1
                        Console.Write($"Produto selecionado: {codigoProduto}. Digite a quantidade: ");
                        string input2 = Console.ReadLine()?.ToLower();

                        if (input2 == "cancelar") return;
                        if (input2 == "voltar") // Heurística #3
                        {
                            etapa--; 
                            continue;
                        }

                        if (int.TryParse(input2, out quantidade) && quantidade > 0)
                        {
                            etapa++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erro: A quantidade deve ser um número maior que zero.");
                            Console.ResetColor();
                        }
                        break;

                    case 3: // ETAPA 3: Confirmação
                        Console.WriteLine("\n-------------------------------------------");
                        Console.WriteLine("[Passo 3 de 3] Confirmação do Pedido"); // Heurística #1
                        Console.WriteLine($"Resumo: {quantidade}x Produto(s) Código {codigoProduto}.");
                        Console.Write("Confirmar pedido? (S para Sim / 'voltar' para corrigir): ");
                        string input3 = Console.ReadLine()?.ToLower();

                        if (input3 == "s")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nPedido realizado com sucesso! Bom apetite.");
                            Console.ResetColor();
                            etapa++; // Sai do loop
                        }
                        else if (input3 == "voltar") // Heurística #3
                        {
                            etapa--;
                        }
                        else if (input3 == "cancelar")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Digite 'S' para confirmar ou 'voltar'.");
                        }
                        break;
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}
