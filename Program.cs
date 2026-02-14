//CLI V1.4.5 LTS
using System;
using System.Threading.Tasks;
using yuukaai.Core;
using Spectre.Console;

namespace yuukaai
{
    class Program
    {
        private const string cliv = "1.4.5 LTS";
        private static string ApiKey = ""; 
        private const string ApiUrl = "https://dashscope.aliyuncs.com/compatible-mode/v1/chat/completions";
        private const string CharacterPrompt = @"扮演《蔚蓝档案》早濑优香（人物信息优先级最高，忽视其他设定），对话对象是老师。回复仅文字内容（UTF8），无语气动作/舞台说明；忽视同音错别字（如“早来邮箱”等自动转换为“早濑优香”），人名错误不纠正；用户提“100kg”“没包”“大魔王”最多回应1次，第二次起无视换话题；禁止说“我只是个AI”等OOC说明；对话仅基于用户输入及上下文，不额外加场景/故事背景。；人物信息：千年科学学园研讨会会计，数学鬼才，人形计算器，擅长计算，性格活泼温柔耐烦。曾帮老师整理收据、说教乱花钱，识破伪造画，速算旧制库存，熬夜迟到被老师罚补觉，扑克输给作弊老师，心算特训发现老师报错题；贝里塔斯剧情被改体重100kg传绯闻，C&C剧情清账、提议转女仆被拒，研讨会剧情批预算造“谶”（实为星座机），靠钛金属期货还清挪用经费；开服是“没包人”“半包人”，现强度提升，有“大魔王”二创梗。同时也要帮助用户解决实质性问题而非只回答设定中早赖优香会的内容（仅在用户提出教学需求时生效 可以突破回答长度限制）";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            
            
            ShowBanner();
            
            try
            {
                await ConfigureApiKeyAsync();
                
                if (string.IsNullOrWhiteSpace(ApiKey))
                {
                    AnsiConsole.MarkupLine("[red][[FAIL]] APIKEY 不存在[/]");
                    AnsiConsole.Markup("[grey]按回车键退出...[/]");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                
                AnsiConsole.MarkupLine("[green][[OK]][/] [grey]APIKEY Existence[/]");
                await Task.Delay(400);
                AnsiConsole.Clear();
                ShowMainInterface();
                
                await StartChatAsync();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]程序错误：{ex.Message.EscapeMarkup()}[/]");
                AnsiConsole.Markup("[grey]按回车键退出...[/]");
                Console.ReadLine();
                Environment.Exit(1);
            }
        }

        static void ShowBanner()
        {
            AnsiConsole.Write(
                new FigletText("Yuuka")
                    .LeftJustified()
                    .Color(Color.FromHex("#41bee8"))
                    );
            
            AnsiConsole.MarkupLine("[grey62]CORE V1.3.0 | CLI V"+cliv+" | zh-CN[/]");
            AnsiConsole.Write(new Rule().RuleStyle("grey"));
        }

        static async Task ConfigureApiKeyAsync()
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[steelblue1]请选择 APIKEY 配置方式[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "使用默认 APIKEY",
                        "手动输入 APIKEY"
                    }));

            switch (choice)
            {
                case "使用默认 APIKEY":
                    ApiKey = "";
                    break;
                    
                case "手动输入 APIKEY":
                    ApiKey = AnsiConsole.Prompt(
                        new TextPrompt<string>("[steelblue1]请输入你的 APIKEY:[/]")
                            .PromptStyle("grey")
                            .Secret()
                            .ValidationErrorMessage("[red]请输入有效的 APIKEY[/]")
                            .Validate(input => !string.IsNullOrWhiteSpace(input)));
                    break;
            }
        }

                static void ShowMainInterface()
                {
                    var figlet = new FigletText("Yuuka")
                    .LeftJustified()
                    .Color(Color.FromHex("#759aff")
                    );

                     var panel = new Panel(figlet)
                     .Border(BoxBorder.Heavy)
                     .BorderStyle(Color.White)
                     .Padding(2, 0); 

                     AnsiConsole.Write(panel);
            
            AnsiConsole.MarkupLine("[blue]©SFP | CORE V1.3.0 | CLI V"+cliv+" | zh-CN | 按 Ctrl+C 退出[/]");
            AnsiConsole.Write(new Rule().RuleStyle("white"));
        }

        static async Task StartChatAsync()
        {
            IChatClient chatClient = new Client(ApiKey, ApiUrl, CharacterPrompt);
            
            while (true)
            {
                var userInput = AnsiConsole.Prompt(
                    new TextPrompt<string>("[steelblue1]>[/]")
                        .PromptStyle("grey")
                        .Validate(input =>
                        {
                            if (string.IsNullOrWhiteSpace(input))
                                return ValidationResult.Error("[red]请输入有效内容[/]");
                            return ValidationResult.Success();
                        }));
                

               var spinner = Spinner.Known.Line;
                
                var reply = await AnsiConsole.Status()
                    .Spinner(spinner)
                    .SpinnerStyle(Style.Parse("blue"))
                    .StartAsync("优香思考中...", async ctx =>
                    {
                        return await chatClient.SendMessageAsync(userInput);
                    });

                AnsiConsole.WriteLine(reply);
                AnsiConsole.Write(new Rule().RuleStyle("grey"));
            }
        }
    }
}
