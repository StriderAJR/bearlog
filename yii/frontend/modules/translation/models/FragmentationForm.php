<?php
namespace frontend\modules\translation\models;

use Yii;
use yii\base\Model;
use frontend\models\User;

use frontend\models\Translation;
use frontend\models\Category;
use frontend\models\TranslationBook;
use frontend\models\TranslationPart;
use frontend\models\PartFragment;

class FragmentationForm extends Model
{
    public function rules()
    {
        // return [
        //     [['name','nameOriginal','coverLink','isPrivate','authorName','authorOriginalName','year','fromLanguageID', 'toLanguageID'], 'required', 'message' => 'Это поле не может быть пустым'],
        //     [['bookFile'], 'file', 'extensions' => 'txt'],
        // ];
    }

    public static function divideBook($uploadedFileName, $fragmentationWay, $translationBookID)
    {
        $translationBook = TranslationBook::findOne($translationBookID);
        $fragments = [];

        if ($fragmentationWay == 'sentences')
        {
            $fragments = static::divideBookBySentences(file_get_contents($uploadedFileName));
        } 
        else if ($fragmentationWay == 'paragraphs') 
        {
            $fragments = static::divideBookByParagraphs(file_get_contents($uploadedFileName));
        }
        // else if ($fragmentationWay == 'manually')
        // {

        // }

        $part = new TranslationPart();
        $part->part_id = uniqid();
        $part->translation_id = $translationBook->translation_id;
        $part->save();

        foreach ($fragments as $fragmentText) {
            $fragment = new PartFragment();
            $fragment->fragment_id = uniqid();
            $fragment->part_id = $part->part_id;
            $fragment->original_text = $fragmentText;
            if (!$fragment->save()) {
                throw new \Exception("Can't create a fragment", 1);
                
            }
        }

        return $translationBookID;
    }

    public static function divideBookBySentences($text)
    {
        return preg_split('/(?<=[.?!])\s+(?=[a-z])/i', $text);
    }

    public static function divideBookByParagraphs($text)
    {
        return preg_split('/\r\n|\n|\r/', $text, -1, PREG_SPLIT_NO_EMPTY);
    }

    public static function divideBookManually($text)
    {
        //...
    }

}