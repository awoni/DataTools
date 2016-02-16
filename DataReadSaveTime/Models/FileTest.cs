using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataReadSaveTime.Models
{
    public class FileTest
    {
        private const string _content = @"吾輩は猫である。名前はまだ無い。　どこで生れたかとんと見当がつかぬ。何でも薄暗いじめじめした所でニャーニャー泣いていた事だけは記憶している。吾輩はここで始めて人間というものを見た。しかもあとで聞くとそれは書生という人間中で一番獰悪な種族であったそうだ。この書生というのは時々我々を捕えて煮て食うという話である。しかしその当時は何という考もなかったから別段恐しいとも思わなかった。ただ彼の掌に載せられてスーと持ち上げられた時何だかフワフワした感じがあったばかりである。掌の上で少し落ちついて書生の顔を見たのがいわゆる人間というものの見始であろう。この時妙なものだと思った感じが今でも残っている。";

        public static async Task FileSave()
        {
            for(int n = 0; n < 5000; n++)
            {
                try
                {
                    using (var fs = new FileStream(Path.Combine("data", "d" + n + ".json"), FileMode.Create, FileAccess.Write))
                    using (var sr = new StreamWriter(fs))
                    {
                        string s = $"{{\"id\":\"{n}\",\"content\":\"{_content}\"}}";
                        await sr.WriteAsync(s);
                    }
                }
                catch (Exception e1)
                {
                    LoggerClass.NLogInfo("保存エラー: " + e1.Message);
                }
            }
        }

        public static async Task FileRead()
        {
            for (int n = 0; n < 5000; n++)
            {
                try
                {
                    using (var fs = new FileStream(Path.Combine("data", "d" + n + ".json"), FileMode.Open, FileAccess.Read))
                    using (var sr = new StreamReader(fs))
                    {
                        string s = await sr.ReadToEndAsync();
                    }
                }
                catch (Exception e1)
                {
                    LoggerClass.NLogInfo("読み込みエラー: " + e1.Message);
                }
            }
        }
    }
}
