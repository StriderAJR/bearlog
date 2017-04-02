<?php
use yii\helpers\Html;
use yii\widgets\ActiveForm;
use yii\db\ActiveRecord;
?>
<?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'name')->label('Ваше имя') ?>
    <?= $form->field($model, 'password') ?>
	<?= $form->field($model, 'email') ?>

	$countries = Country::find()->orderBy('name')->all();

    <div class="form-group">
        <?= Html::submitButton('Отправить', ['class' => 'btn btn-primary']) ?>
    </div>

<?php ActiveForm::end(); ?>