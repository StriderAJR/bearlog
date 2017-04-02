<?php
namespace frontend\modules\home\models;

use yii\base\Model;
use common\models\User;

class SignupForm extends Model
{
    public $email;
    public $password;
    public $passwordRepeat;
    public $role;


    public function rules()
    {
        return [
            ['email', 'filter', 'filter' => 'trim'],
            ['email', 'required'],
            ['email', 'email'],
            ['email', 'string', 'max' => 255],
            ['email', 'unique', 'targetClass' => '\common\models\User', 'message' => 'This email address has already been taken.'],

            ['password', 'required'],
            ['passwordRepeat', 'required'],
            ['password', 'string', 'min' => 6],
        ];
    }

   
    public function signup()
    {
        if (!$this->validate()) {
            return null;
        }
        
        $user = new User();
        $user->email = $this->email;
        $user->setPassword($this->password);

        // var_dump($user);
        // var_dump($user->save());
        // exit();
        
        return $user->save() ? $user : null;
    }
}
