<?php
namespace app\modules\translation\controllers;

use yii\web\Controller;
use Yii;

use frontend\modules\translation\models\CreateBookForm;
use frontend\modules\translation\models\FragmentationForm;
use frontend\models\Language;
use yii\helpers\ArrayHelper;

use frontend\models\Translation;
use frontend\models\TranslationBook;
use frontend\models\TranslationPart;
use frontend\models\PartFragment;

class CreationController extends Controller 
{
	public function behaviors()
    {
        return [
            'access' => [
                'class' => \yii\filters\AccessControl::className(),
                'rules' => [
                    [
                        'allow' => false,
                        'roles' => ['?'],
                    ],
                    [
                        'allow' => true,
                        'roles' => ['@'],
                    ],
                ],
            ],
        ];
    }
    
    public function actionIndex()
    {
        return $this->render('index', []);
    }

    public function actionUpload($category)
    {
        $model = [];
        $model['languages'] = Language::find()
                                    ->asArray()
                                    ->all();

        $model['languages'] = ArrayHelper::map($model['languages'],'language_id','name');

        if ($category == 'book')
        {
            $view = 'upload-book';
            $model['form'] = new CreateBookForm();

            if (Yii::$app->request->isPost) {
            // var_dump(Yii::$app->request->post());
            // exit();
                if ($model['form']->load(Yii::$app->request->post())) {
                    if (isset(Yii::$app->request->post()['makePrivate'])) {
                        $model['form']->isPrivate = true;
                    } else {
                        $model['form']->isPrivate = false;
                    }
                    
                    $model['form']->upload();

                    $translationData = $model['form']->create();
                    if ($translationData)
                    {
                        return $this->redirect(["/translation/creation/fragmentation",
                                                'uploadedFileName' => $translationData['uploadedFileName'],
                                                'translationBookID' => $translationData['translationBookID'],
                                            ]);
                    }
                }
            }
        }

        return $this->render($view, [
                'model' => $model,
            ]);   
    }

    public function actionFragmentation($uploadedFileName, $translationBookID)
    {
        if (Yii::$app->request->isPost) {
            // Only Books ????
            $translationBookID = FragmentationForm::divideBook($uploadedFileName, Yii::$app->request->post()['fragmentationWay'], $translationBookID);

            if ($translationBookID) {
                return $this->redirect(["/translation/creation/data",
                                            'translationBookID' => $translationBookID,
                                        ]);
            }
        }

        return $this->render('fragmentation', [
                'model' => [
                    'uploadedFileName' => $uploadedFileName,
                     'translationBookID' => $translationBookID,
                ]
            ]);           
    }

    public function actionData()
    {
        /* For Book */
        if (isset(Yii::$app->request->get()['translationBookID'])) 
        {
            return $this->render('data-book', [
                    'model' => TranslationBook::getFullBookData(Yii::$app->request->get()['translationBookID']),
                ]);           
        }
        // else if ()
        // {

        // }
        throw new Exception("Invalid input params", 1);
    }
}