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

### 防火牆 設定
加入TCP:1801規則
- 控制台(小圖示) > 防火牆 > 進階設定 > 輸入規則(右鍵) > 新增規則 > 連接埠 > TCP:1801


### Decision Tree
Implement the partition that occurs at the rootnode<br>
ID3 (Iterative Dichotomiser 3) is an algorithm invented by Ross Quinlan used to generate a decision tree from a dataset.<br>
<img src="https://github.com/jui-pung/MachineLearningRelatedAlgorithms/blob/8d7bedd2197b5f5986328ef29921c06db5e67a62/allelectronics%20customer%20database.png" width="400"/>

### HMM
Problem :<br>
<img src="https://github.com/jui-pung/MachineLearningRelatedAlgorithms/blob/9b40bc0cd943e2de0c73f330da10442e592c1691/Hidden%20Markov%20Model%20Problem.png" width="400"/>

[Description file](https://github.com/jui-pung/MachineLearningRelatedAlgorithms/blob/b37c5f4a351c03b5ceef5289b75a3dae9fa05876/HMM_java/Hidden%20Markov%20Model.pdf)
