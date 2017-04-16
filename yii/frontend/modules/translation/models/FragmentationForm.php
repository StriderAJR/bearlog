<?php
namespace frontend\modules\translation\models;

use Yii;
use yii\base\Model;
use frontend\models\User;

use frontend\models\Translation;
use frontend\models\Category;
use frontend\models\TranslationBook;

class FragmentationForm extends Model
{
    public function rules()
    {
        // return [
        //     [['name','nameOriginal','coverLink','isPrivate','authorName','authorOriginalName','year','fromLanguageID', 'toLanguageID'], 'required', 'message' => 'Это поле не может быть пустым'],
        //     [['bookFile'], 'file', 'extensions' => 'txt'],
        // ];
    }
    
    public function upload()
    {
        
    }

}