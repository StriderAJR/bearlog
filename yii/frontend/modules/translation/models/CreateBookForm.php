<?php
namespace frontend\modules\translation\models;

use Yii;
use yii\base\Model;
use frontend\models\User;

use frontend\models\Translation;
use frontend\models\Category;
use frontend\models\TranslationBook;
use yii\web\UploadedFile;

class CreateBookForm extends Model
{
    public $name;
    public $nameOriginal;
    public $fromLanguageID;
    public $toLanguageID;
    public $coverLink;
    public $isPrivate;
    public $authorName;
    public $authorOriginalName;
    public $year;

    public $bookFile;
    public $originalText;
    public $uploadedFileName = NULL;

    public function rules()
    {
        return [
            [['name','nameOriginal','coverLink','isPrivate','authorName','authorOriginalName','year','fromLanguageID', 'toLanguageID'], 'required', 'message' => 'Это поле не может быть пустым'],
            [['bookFile'], 'file', 'extensions' => 'txt'],
            ['originalText', 'string'],
        ];
    }
    
    public function upload()
    {
        $this->bookFile = UploadedFile::getInstance($this, 'bookFile');
        $this->uploadedFileName = 'uploads/'.uniqid();

        // var_dump($this->bookFile);
        // exit();
        if ($this->bookFile) {
            $this->uploadedFileName =  $this->uploadedFileName.'.'.$this->bookFile->extension;
            $this->bookFile->saveAs($this->uploadedFileName);


            if (!trim(file_get_contents($this->uploadedFileName)))
            {
                /* Загружаем из текстового поля, если файл пустой: */
                file_put_contents($this->uploadedFileName, $this->originalText);
                rename($this->uploadedFileName, $this->uploadedFileName.'.txt');
                $this->uploadedFileName = $this->uploadedFileName.'.txt';

            }
        } else {
            file_put_contents($this->uploadedFileName, $this->originalText);
            rename($this->uploadedFileName, $this->uploadedFileName.'.txt');
            $this->uploadedFileName = $this->uploadedFileName.'.txt';
        }


        return;
    }

    public function create()
    {
        $user = \Yii::$app->user->identity;
        $category = Category::findOne(['name' => 'book']);
        $translation = new Translation();
        
        $translation->name = $this->name;
        $translation->name_original = $this->nameOriginal;
        $translation->from_language_id = $this->fromLanguageID;
        $translation->to_language_id = $this->toLanguageID;
        $translation->cover_link = $this->coverLink;
        $translation->is_private = $this->isPrivate;
        $translation->is_finished = false;
        $translation->category_id = $category->category_id;
        $translation->creator_id = $user->user_id;
        $translation->translation_id = uniqid(null, true);
        $translation->save();

        $translationID = $translation->translation_id;

        $translationBook = new TranslationBook();
        $translationBook->translation_id = $translationID;
        $translationBook->author_name = $this->authorName;
        $translationBook->author_original_name = $this->authorOriginalName;
        $translationBook->year = $this->year;
        $translationBook->book_id = uniqid(null, true);
        $translationBook->save();

        $translationBookID = $translationBook->book_id;

        return [
            'translationID' => $translationID,
            'translationBookID' => $translationBookID,
            'uploadedFileName' => $this->uploadedFileName,
        ];
    }
}