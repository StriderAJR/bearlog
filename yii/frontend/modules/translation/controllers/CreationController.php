<?php
namespace app\modules\translation\controllers;

use yii\web\Controller;
use Yii;

use frontend\modules\translation\models\CreateBookForm;
use frontend\models\Language;
use yii\helpers\ArrayHelper;

use frontend\models\Translation;
use frontend\models\TranslationBook;

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
                                                'translationID' => $translationData['translationID'],
                                                'translationBookID' => $translationData['translationBookID'],
                                                'uploadedFileName' => $translationData['uploadedFileName'],
                                            ]);
                    }
                }
            }
        }

        return $this->render($view, [
                'model' => $model,
            ]);   
    }

    public function actionFragmentation()
    {
        $get = Yii::$app->request->get();

        return $this->render('fragmentation', [
                'model' => [
                    'translation' => Translation::findOne($get['translationID']),
                    'book' => TranslationBook::findOne($get['translationBookID']),
                    'originalText' => file_get_contents($get['uploadedFileName']),
                ]
            ]);           
    }

    public function actionCheck()
    {
        return $this->render('check', []);           
    }
}