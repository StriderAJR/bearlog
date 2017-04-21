<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;
use yii\helpers\ArrayHelper;

use frontend\models\Translation;
use frontend\models\TranslationBook;
use frontend\models\TranslationPart;
use frontend\models\PartFragment;

use frontend\models\Language;

class TranslationBook extends Translation 
{
	public static function tableName() {
		return 'book';
	}

	public static function getFullBookData($translationBookID)
	{
		$translationBook = TranslationBook::findOne($translationBookID);
        $translation = Translation::findOne($translationBook->translation_id);
        $translationParts = TranslationPart::find()  
                            ->where(['translation_id' => $translationBook->translation_id])
                            ->asArray()
                            ->all();

        $partsText = [];

        foreach ($translationParts as $translationPart) {
            $partFragments = PartFragment::find()  
                                ->where(['part_id' => $translationPart['part_id']])
                                ->asArray()
                                ->all();

            $partsText[] = $partFragments;
        }   

        $languages = Language::find()
                            ->asArray()
                            ->all();

        foreach ($languages as $language) {
        	if ($language['language_id'] == $translation->from_language_id) {
        		$translation->from_language_id = $language['name'];
        	}

        	if ($language['language_id'] == $translation->to_language_id) {
        		$translation->to_language_id = $language['name'];
        	}
        }

        return [
                    'partsText' => $partsText,
                    'translation' => $translation,
                    'translationBook' => $translationBook,
                    'languages' => $languages,
               ];
	}
}
