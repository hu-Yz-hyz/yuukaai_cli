#  YuukaAI CLI（YuukaAI V1）

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-GPL%20v3-blue.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/Platform-Windows%7CLinux%7CmacOS-blue)](https://github.com/hu-Yz-hyz/yuukaai_cli)
[![BlueArchive](https://img.shields.io/badge/Blue%20Archive-YUUKA-%235BA3E8?style=flat)](https://bluearchive-cn.com/)

*注：在CLI V1.3.0开始对此项目的基本框架开源*

*CORE V1.3.0版本以后修改了部分文件的命名*

> 🌸 与千年科学学园研讨会会计早濑优香（Hayase Yuuka）在终端中聊天

## 🚀 快速开始

### 配置 API Key

**自定义**：在 `请选择你要使用的APIKEY:` 中输入`2`后输入API Key


> 🔑 获取 API Key：[阿里云百炼](https://bailian.console.aliyun.com/cn-beijing#/home)

### 二次构建发布可执行文件

*公开代码部分无默认APIKEY*

```bash
# Windows
dotnet publish -c Release -r win-x64 --self-contained true

# Linux
dotnet publish -c Release -r linux-x64 --self-contained true

# macOS
dotnet publish -c Release -r osx-x64 --self-contained true
```

## 📖 使用说明

启动程序后，你会看到早濑优香的 ASCII Logo 和加载信息：

```
 __   __  _   _   _   _   _  __     _     
 \ \ / / | | | | | | | | | |/ /    / \    
  \ V /  | | | | | | | | | ' /    / _ \   
   | |   | |_| | | |_| | | . \   / ___ \  
   |_|    \___/   \___/  |_|\_\ /_/   \_\ 
CORE V1.3.0|CLI V1.3.2|zh-CN
```

在 `>` 提示符后输入消息即可开始对话：

```
> 你好优香！
你好老师！今天有什么我可以帮你的吗？无论是收据整理还是数学问题都可以交给我哦。
```

按 `Ctrl+C` 退出程序。

## 🏗️ 项目结构

```
yuukaai_cli/
├── Program.cs              # 程序入口点
├── yuukaai_cli.csproj      # 项目配置文件
├── Core/
│   ├── DeepSeekClient.cs   # AI 对话客户端
│   └── Models/
│       ├── Message.cs      # 消息模型
│       ├── ChatResponse.cs # API 响应模型
│       └── ChatChoice.cs   # 选择项模型
└── favicon.ico             # 应用程序图标（可选）
```

## 🔧 自定义角色设定

你可以在 `Program.cs` 中修改 `CharacterPrompt` 常量来自定义角色行为：


## 📜 许可证

本项目基础框架采用 [GNU General Public License v3.0](LICENSE) 许可证开源。

## 🙏 致谢

- [蔚蓝档案](https://bluearchive-cn.com/) - 早濑优香角色与蔚蓝档案的原作者
- [DeepSeek](https://deepseek.ai/) - 提供强大的语言模型
- [阿里云百炼](https://bailian.console.aliyun.com/cn-beijing#/home) - API 服务

### 欢迎提交 Issue 和 Pull Request！

## 开发计划

> 增加长期记忆能力

>支持自定义apikey及模型

>优化UI

>支持MD及脚本运行（可作为辅助工具化）

>快捷程序打开方式

## 📧 联系方式

如有问题或建议，欢迎通过以下方式联系：

- GitHub Issues: [提交问题](https://github.com/hu-Yz-hyz/yuukaai_cli/issues)
- Email: huyzhong@outlook.com
- BiliBili：[BiliBili](https://space.bilibili.com/1523473466?spm_id_from=333.1007.0.0)

捐赠：[爱发电](https://afdian.com/a/hu0503hu)

---



<p align="center">
  <i>"千年科学学园研讨会会计，随时为老师服务！"</i>
</p>





