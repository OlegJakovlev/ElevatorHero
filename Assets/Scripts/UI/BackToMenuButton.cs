using UI.Select;

namespace UI
{
    public class BackToMenuButton : Option
    {
        public override void OnSelect()
        {
            base.OnSelect();
            CustomSceneManager.Instance.LoadSceneByName("Menu");
        }
    }
}