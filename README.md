## MSMQ_Outgoing-Queues(傳出佇列)

## 實現內容
- 利用.NET透過MSMQ傳送訊息 兩台主機於相同區域網路裡 達到聊天室效果
- 說明連線方式與佇列 防火牆設定

### 連線方式
var queue = new MessageQueue(@"FormatName:DIRECT=TCP:172.10.10.1\private$\chatbox");
- TCP:172.10.10.1為接收方ip位置
- chatbox為接收方預存放的私有佇列名稱

### 接收方 佇列設定
- 訊息佇列(右鍵) > 內容 > 伺服器安全性 > 取消勾選(停用未驗證的RPC呼叫)
- 接收方私有佇列名稱(右鍵) > 內容 > 安全性 > ANONYMOUS LOGON(沒有的話須新增) > 勾選(完全控制) 
<img src="https://github.com/jui-pung/MSMQ_Outgoing-Queues/blob/7be83c630b6a98ac8ffe3bd04cf4c2bb134fe3ac/02.png" width="400"/>
<img src="https://github.com/jui-pung/MSMQ_Outgoing-Queues/blob/7be83c630b6a98ac8ffe3bd04cf4c2bb134fe3ac/01.png" width="400"/>

### 防火牆 設定
加入TCP:1801規則
- 控制台(小圖示) > 防火牆 > 進階設定 > 輸入規則(右鍵) > 新增規則 > 連接埠 > TCP:1801
<img src="https://github.com/jui-pung/MSMQ_Outgoing-Queues/blob/a8da29c61a45e8bad451e6d5402d9d6ce9d7969d/03.png" width="400"/>
