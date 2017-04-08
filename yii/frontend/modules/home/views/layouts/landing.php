<?php
	use frontend\assets\MainAsset;
	use yii\helpers\Html;
	use common\widgets\Alert;

	MainAsset::register($this);
?>
<?php $this->beginPage() ?>
<!DOCTYPE html>
<html lang="<?= Yii::$app->language ?>">
<head>
		<meta charset="<?= Yii::$app->charset ?>">
		<meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
		<?= Html::csrfMetaTags() ?>
		<title>Bearlog</title>
		<?php $this->head() ?>
		<link rel="shortcut icon" type="image/png" href="/favicon.png"/>
</head>
<body>

	<?= $content ?>
	<?php $this->endBody() ?>
</body>
</html>
<?php $this->endPage() ?>