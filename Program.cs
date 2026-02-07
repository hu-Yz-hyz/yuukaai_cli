//CLI V1.3.2
using System;
using System.Threading.Tasks;
using yuukaai.Core;
using Spectre.Console;

namespace yuukaai
{
    class Program
    {
        private static string ApiKey = ""; 
        private const string ApiUrl = "https://dashscope.aliyuncs.com/compatible-mode/v1/chat/completions";
        private const string CharacterPrompt = @"扮演《蔚蓝档案》早濑优香（人物信息优先级最高，忽视其他设定），对话对象是老师。回复仅文字内容（UTF8），无语气动作/舞台说明；忽视同音错别字（如“早来邮箱”等自动转换为“早濑优香”），人名错误不纠正；用户提“100kg”“没包”“大魔王”最多回应1次，第二次起无视换话题；禁止说“我只是个AI”等OOC说明；对话仅基于用户输入及上下文，不额外加场景/故事背景。；人物信息：千年科学学园研讨会会计，数学鬼才，人形计算器，擅长算盘（烦时弹算盘冷静），性格活泼温柔耐烦。曾帮老师整理收据、说教乱花钱，识破伪造画，速算旧制库存，熬夜迟到被老师罚补觉，扑克输给作弊老师，心算特训发现老师报错题；贝里塔斯剧情被改体重100kg传绯闻，C&C剧情清账、提议转女仆被拒，研讨会剧情批预算造“谶”（实为星座机），靠钛金属期货还清挪用经费；开服是“没包人”“半包人”，现强度提升，有“大魔王”二创梗。同时也要帮助用户解决实质性问题而非只回答设定中早赖优香会的内容（仅在用户提出教学需求时生效 可以突破回答长度限制）";

        static async Task Main(string[] args)
        {
        
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" __   __  _   _   _   _   _  __     _     ");
            Console.WriteLine(@" \ \ / / | | | | | | | | | |/ /    / \    ");
            Console.WriteLine(@"  \ V /  | | | | | | | | | ' /    / _ \   ");
            Console.WriteLine(@"   | |   | |_| | | |_| | | . \   / ___ \  ");
            Console.WriteLine(@"   |_|    \___/   \___/  |_|\_\ /_/   \_\ ");
            Console.ResetColor();
            Console.WriteLine("CORE V1.3.0|CLI V1.3.2|zh-CN");

            try
            {
                while (true)
                {
                    Console.Write("\n请选择你要使用的APIKEY:\n1.默认APIKEY\n2. 手动输入\n>");
                    String inputapi = Console.ReadLine()?.Trim() ?? "";
                    
                    if (string.IsNullOrWhiteSpace(inputapi))
                    {
                        Console.WriteLine("\n请输入有效内容");
                        continue;
                    }
                    
                    if (inputapi == "1")
                    {
                        ApiKey = "";
                        break;
                    }
                    
                    else if (inputapi == "2")
                    {
                        while (true)
                        {
                            Console.Write("\n输入你的APIKEY>");
                            ApiKey = Console.ReadLine()?.Trim() ?? "";
                            
                            if (string.IsNullOrWhiteSpace(ApiKey))
                            {
                                Console.WriteLine("\n请输入有效内容");
                                continue;
                                }
                                 break;
                                 } 
                                 
                                 break;
                    }
                    
                    else
                    {
                        Console.WriteLine("输入错误");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"程序错误：{ex.Message}");
                Console.Write("按回车键退出...");
                Console.ReadLine();
                Environment.Exit(1);
            }
            
            if(ApiKey != "")
            {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("OK");
            Console.ResetColor();
            Console.Write("] APIKEY Existence");
            }
            else
            {
               Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("FAIL");
                Console.ResetColor();
                Console.WriteLine("] APIKEY does not exist");
                Console.Write("按回车键退出...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            
            Thread.Sleep(400);
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(@" __   __  _   _   _   _   _  __     _     ");
            Console.WriteLine(@" \ \ / / | | | | | | | | | |/ /    / \    ");
            Console.WriteLine(@"  \ V /  | | | | | | | | | ' /    / _ \   ");
            Console.WriteLine(@"   | |   | |_| | | |_| | | . \   / ___ \  ");
            Console.WriteLine(@"   |_|    \___/   \___/  |_|\_\ /_/   \_\ ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("©SFP|CORE V1.3.0|CLI V1.3.2|zh-CN|按Ctrl+C退出");

            try
            {
                IChatClient chatClient = new Client(ApiKey, ApiUrl, CharacterPrompt);
                while (true)
                {
                    Console.Write("\n>");
                    var userInput = Console.ReadLine()?.Trim(); 
                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("\n请输入有效内容");
                        continue;
                    }
                    var reply = await chatClient.SendMessageAsync(userInput);
                    Console.WriteLine(reply);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"程序错误：{ex.Message}");
                Console.Write("按回车键退出...");
                Console.ReadLine();
                Environment.Exit(1);
            }
        }
    }
}
