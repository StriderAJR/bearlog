<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;

use frontend\models\Translation;
use frontend\models\TranslationBook;
use frontend\models\TranslationPart;
use frontend\models\PartFragment;

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

        return [
                    'partsText' => $partsText,
                    'translation' => $translation,
                    'translationBook' => $translationBook,
               ];
	}
}
